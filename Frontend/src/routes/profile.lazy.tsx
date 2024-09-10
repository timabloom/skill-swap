import { createLazyFileRoute } from '@tanstack/react-router'
import { useUser } from '@clerk/clerk-react'
import Header from '../layouts/header'
import { useEffect, useState } from 'react'
import { getProfile } from '../apiRequests/getProfile'
import UserProfile from '../components/userProfile'

export const Route = createLazyFileRoute('/profile')({
  component: Profile,
})

interface Profile {
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

function Profile() {
  const { user } = useUser()
  const [profile, setProfile] = useState<Profile>()

  useEffect(() => {
    const fetchProfile = async () => {
      setProfile(await getProfile(user?.id))
    }

    fetchProfile()
  }, [user?.id])

  console.log(profile)

  return (
    <>
      <Header />
      <h1 className="text-3xl text-center pt-8">Profile</h1>
      <UserProfile profile={profile} />
    </>
  )
}
