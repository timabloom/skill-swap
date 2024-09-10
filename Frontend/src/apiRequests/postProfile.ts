import { PostProfileBody } from "../types"
import { UploadProfileImageToCloud } from "./uploadImage"

export async function postProfile(postProfileBody: PostProfileBody, fileInput?: FileList) {
    if (!postProfileBody.clerkId) return

    try {
        const imageUrl = await UploadProfileImageToCloud(fileInput)
        const response = await fetch('http://localhost:5257/Profiles', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(
                { ...postProfileBody, imageUrl: imageUrl }
            ),
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
