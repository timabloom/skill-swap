export async function getProfile(clerkId?: string) {
    console.log(clerkId)
    try {
        const response = await fetch(`http://localhost:5257/Profiles/${clerkId}`, {
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