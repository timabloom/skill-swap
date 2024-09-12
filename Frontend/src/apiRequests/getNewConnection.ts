export async function getNewConnection(clerkId: string | undefined, publicId: string | undefined) {
    try {
        const response = await fetch(`http://localhost:5257/Profiles/Connections/New/${clerkId}?PublicId=${publicId}`, {
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