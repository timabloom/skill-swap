import { useUser } from "@clerk/clerk-react"
import { postConnection } from "../apiRequests/postConnection"
import { ProfileResponse } from "../types"
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import { getProfile } from "../apiRequests/getProfile"

function UserProfile({ profile }: { profile: ProfileResponse | undefined }) {
    const { user } = useUser()
    const queryClient = useQueryClient()

    const mutation = useMutation({
        mutationFn: () => postConnection(user?.id, profile?.publicId),
        onSuccess: () => {
            // Invalidate and refetch
            queryClient.invalidateQueries({ queryKey: ['matches'] })
        },
    })

    const { data } = useQuery<ProfileResponse>({
        queryKey: ['profile'], queryFn: () => getProfile(user?.id)
    })

    const isConnected = data?.connections?.find((connection) => connection.profileMatchPublicId === profile?.publicId)

    return (
        <div className="flex items-center justify-center p-10">
            <div className="flex flex-col max-w-2xl border rounded-md p-12" >

                {!profile?.imageUrl &&
                    <div className="border rounded-2xl max-w-72 h-72 flex flex-col justify-end items-center">
                        <div className="w-24 h-24 bg-gray-300 rounded-full mb-2"></div>
                        <div className="w-24 h-32 bg-gray-300 rounded-t-full"></div>
                    </div>}
                {profile?.imageUrl && <img className="rounded-2xl  max-w-72 h-72 " src={profile?.imageUrl} alt="profile picture" />}

                <div className="flex pb-2 pt-2 gap-1">
                    <p className="text-lg font-bold">Name:</p>
                    <p className="text-lg">{profile?.name}</p>
                </div>
                {isConnected?.isAccepted === true && profile?.contactInformation &&
                    <>
                        <p className="font-bold text-lg">Contact Information</p>
                        <p>{profile?.contactInformation?.email}</p>
                    </>
                }
                <div className="pb-2 pt-2">
                    <p className="text-lg font-bold">About Myself</p>
                    <p className="text-lg">{profile?.bio}</p>
                </div>
                <p className="font-bold text-lg">My Skills</p>
                <div className="flex flex-wrap gap-2 pb-2 pt-2">
                    {profile?.skills?.map((skill) =>
                        <p className="badge bg-gray-300 p-4">{skill.tagName}</p>
                    )}
                </div>
                <p className="font-bold text-lg">I Need help with?</p>
                <div className="flex flex-wrap gap-2 pb-2 pt-2">
                    {profile?.needs?.map((skill) =>
                        <p className="badge bg-gray-300 p-4">{skill.tagName}</p>
                    )}
                </div>

                {!profile?.contactInformation &&
                    <>
                        <button className={`mt-4 btn ${mutation.isSuccess || isConnected?.isAccepted === true ? "btn-success" : "btn-primary"}`} onClick={() => mutation.mutate()}>{mutation.isSuccess || isConnected?.isAccepted === true ? "Sent Interest to Connect!" : "Click to Connect!"}</button>
                    </>
                }
            </div>
        </div >
    )
}

export default UserProfile