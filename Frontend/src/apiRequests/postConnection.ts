export async function postConnection(clerkId: string | undefined, publicId: string | undefined) {
    if (!clerkId) return
    try {
        const response = await fetch('http://localhost:5257/Profiles/Connections', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(
                { clerkId: clerkId, profileMatchPublicId: publicId }
            ),
        })

        return response
    } catch (error) {
        if (error instanceof Error) {
            console.log(error.message)
        } else {
            console.log('An unknown error occurred')
        }
    }
}