import { BlobServiceClient } from "@azure/storage-blob"

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