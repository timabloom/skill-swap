import { useUser } from "@clerk/clerk-react"
import { postConnection } from "../apiRequests/postConnection"
import { ProfileResponse } from "../types"
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import { getProfile } from "../apiRequests/getProfile"
import { getNewConnection } from "../apiRequests/getNewConnection"

interface Connections {
    publicId: string,
    profileMatchPublicId: string,
    isAccepted: true
}

function UserProfile({ profile, setNewConnection }: { profile: ProfileResponse | undefined, setNewConnection: React.Dispatch<React.SetStateAction<Connections[]>> }) {
    const { user } = useUser()
    const queryClient = useQueryClient()

    const mutation = useMutation({
        mutationFn: () => postConnection(user?.id, profile?.publicId),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ['matches', 'connections'] })
        },
    })

    const { data } = useQuery<ProfileResponse>({
        queryKey: ['profile'], queryFn: () => getProfile(user?.id)
    })

    const isConnected = data?.connections?.find((connection) => connection.profileMatchPublicId === profile?.publicId)
    const need = data?.needs?.[0]


    const newConnection = useMutation<Connections[]>({
        mutationFn: () => getNewConnection(user?.id, profile?.publicId),
        onSuccess: (data) => {
            queryClient.invalidateQueries({ queryKey: ['newConnection'] })
            setNewConnection(data)
        },

    })

    function handleClick() {
        mutation.mutate()
        newConnection.mutate()
    }

    return (
        <div className="flex flex-col items-center">
            <div className="flex flex-col w-[30rem] border rounded-xl p-12 bg-white" >

                {!profile?.imageUrl &&
                    <div className="border rounded-2xl h-96 flex flex-col justify-end items-center">
                        <div className="w-24 h-24 bg-gray-300 rounded-full mb-2"></div>
                        <div className="w-24 h-32 bg-gray-300 rounded-t-full"></div>
                    </div>}
                {profile?.imageUrl && <img className="rounded-2xl h-96 object-cover" src={profile?.imageUrl} alt="profile picture" />}

                <div className="flex pb-2 pt-4 gap-1">
                    <p className="text-lg font-bold">Name:</p>
                    <p className="text-lg">{profile?.name}</p>
                </div>
                {profile?.contactInformation && profile?.contactInformation &&
                    <>
                        <p className="font-bold text-lg pb-2 pt-4">Contact information</p>
                        <p>{profile?.contactInformation?.email}</p>
                    </>
                }
                <div className="pb-2 pt-4">
                    <p className="text-lg font-bold">About Myself</p>
                    <p className="text-lg">{profile?.bio}</p>
                </div>
                <p className="font-bold text-lg pb-2 pt-4">My Skills</p>
                <div className="flex flex-wrap gap-2 pb-2 pt-2">
                    {profile?.skills?.map((skill) =>
                        <p className={`badge ${need?.tagName === skill.tagName ? "badge-accent" : "bg-gray-300"} p-4`} key={skill.publicId}>{skill.tagName}</p>
                    )}
                </div>
                <p className="font-bold text-lg pb-2 pt-4">I Need help with?</p>
                <div className="flex flex-wrap gap-2 pb-2 pt-2">
                    {profile?.needs?.map((skill) =>
                        <p className="badge bg-gray-300 p-4" key={skill.publicId}>{skill.tagName}</p>
                    )}
                </div>

                {!profile?.contactInformation &&
                    <>
                        <button className={`mt-8 btn ${mutation.isSuccess || isConnected?.isAccepted === true ? "btn-success" : "btn-primary"}`} onClick={handleClick}>{mutation.isSuccess || isConnected?.isAccepted === true ? "Invitation Sent Successfully!" : "Click to Connect!"}</button>
                    </>
                }
            </div>
        </div>
    )
}

export default UserProfile