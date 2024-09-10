export interface ProfileResponse {
    publicId: string
    clerkId: string
    name: string
    bio?: string
    imageUrl?: string
    needs?: Need[]
    skills?: Skill[]
    connections?: Connection[]
    contactInformation?: {
        publicId: string
        email: string
    }
}

interface Skill {
    publicId: string
    tagName: string
}

interface Need {
    publicId: string
    tagName: string
}

interface Connection {
    publicId: string
    isAccepted: boolean
}

export interface PostProfileBody {
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