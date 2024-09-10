import { useUser } from "@clerk/clerk-react"
import { postConnection } from "../apiRequests/postConnection"
import { ProfileResponse } from "../types"

function UserProfile({ profile }: { profile: ProfileResponse | undefined }) {
    const { user } = useUser()

    async function handleConnect() {
        const connection = await postConnection(user?.id, profile?.publicId)
        console.log(connection?.status === 204)
    }

    return (
        <div className="flex items-center justify-center p-10">
            <div className="flex flex-col max-w-2xl border rounded-md p-12" >

                {!profile?.imageUrl &&
                    <div className="border rounded-2xl w-auto h-72 flex flex-col justify-end items-center">
                        <div className="w-24 h-24 bg-gray-300 rounded-full mb-2"></div>
                        <div className="w-24 h-32 bg-gray-300 rounded-t-full"></div>
                    </div>}
                {profile?.imageUrl && <img className="border rounded-2xl w-auto h-72" src={profile?.imageUrl} alt="profile picture" />}

                <div className="flex gap-1">
                    <p>Name</p>
                    <p>{profile?.name}</p>
                </div>
                <div className="flex gap-1">
                    <p>Bio</p>
                    <p>{profile?.bio}</p>
                </div>

                <p>Contact Information</p>
                <div className="flex gap-1">
                    <p>Email</p>
                    <p>{profile?.contactInformation?.email}</p>
                </div>
                <p>Skills</p>
                <p>{profile?.skills?.map((skill) => skill.tagName)}</p>
                <p>Needs</p>
                <p>{profile?.needs?.map((need) => need.tagName)}</p>

                {!profile?.clerkId &&
                    <>
                        <p>Wish to connect?</p>
                        <button className="btn" onClick={() => handleConnect()}>Click to Connect</button>
                    </>
                }
            </div>
        </div >
    )
}

export default UserProfile