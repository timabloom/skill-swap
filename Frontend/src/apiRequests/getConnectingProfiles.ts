import { getProfile } from "./getProfile"

export async function getConnectingProfiles(clerkId: string | undefined) {
    try {
        const profile = await getProfile(clerkId)
        const response = await fetch(`http://localhost:5257/Profiles/Connections/${clerkId}?Skill=${profile.needs[0].tagName}`, {
            headers: {
                'Content-Type': 'application/json',
            }
        })

        return await response.json()
    } catch (error) {
        if (error instanceof Error) {
            console.log(error.message)
        } else {
            console.log('An unknown error occurred')
        }
    }
}