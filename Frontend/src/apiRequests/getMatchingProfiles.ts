export async function getMatchingProfiles(need: string | undefined) {
    try {
        const response = await fetch(`http://localhost:5257/Profiles?Skill=${need}`, {
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