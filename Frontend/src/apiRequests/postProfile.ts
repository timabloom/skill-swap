import { BlobServiceClient } from "@azure/storage-blob"

interface PostProfileBody {
    clerkId?: string
    name: string
    bio?: string
    skills?: skill[]
    needs?: need[]
    email?: string
}

interface skill {
    tagName: string
}

interface need {
    tagName: string
}

export async function postProfile(postProfileBody: PostProfileBody, fileInput?: FileList) {
    if (!postProfileBody.clerkId) return

    console.log(postProfileBody)
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

export async function UploadProfileImageToCloud(fileInput?: FileList) {
    if (fileInput?.length === 0 || !fileInput) return

    const blobContainer: string | undefined = import.meta.env.VITE_AZURE_BLOB_STORAGE_CONTAINER_NAME;
    const blobSasUrl: string | undefined = import.meta.env.VITE_AZURE_BLOCK_STORAGE_SAS_URL;

    if (!blobContainer || !blobSasUrl) {
        throw new Error("An environment variable error occurred")
    }

    const blobServiceClient = new BlobServiceClient(blobSasUrl)
    const containerClient = blobServiceClient.getContainerClient(blobContainer)
    const blockBlobClient = containerClient.getBlockBlobClient(fileInput[0].name)
    const response = await blockBlobClient.uploadData(fileInput[0])

    return response._response.request.url
}