import { ProfileResponse } from "../types"

function UserProfile({ profile }: { profile: ProfileResponse | undefined }) {

    return (
        <div className="flex items-center justify-center p-10">
            <div className="flex flex-col max-w-2xl border rounded-md p-12" >

                <div className="border rounded-2xl w-auto h-72 flex flex-col justify-end items-center">
                    {!profile?.imageUrl &&
                        <>
                            <div className="w-24 h-24 bg-gray-300 rounded-full mb-2"></div>
                            <div className="w-24 h-32 bg-gray-300 rounded-t-full"></div>
                        </>
                    }
                    {profile?.imageUrl && <img src={profile?.imageUrl} alt="profile picture" />}
                </div>
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
            </div>
        </div >
    )
}

export default UserProfile