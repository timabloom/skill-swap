interface PostProfileBody {
    clerkId?: string
    name: string
    bio?: string
    imageUrl?: string
    skills?: string[]
    needs?: string[]
    email?: string
}

export async function postProfile(postProfileBody: PostProfileBody) {
    if (!postProfileBody.clerkId) return;
    try {
        const response = await fetch('http://localhost:5257/Profiles', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(
                postProfileBody
            ),
        })

        console.log(await response.json());
    } catch (error) {
        console.error(error)
    }
}