import { createLazyFileRoute } from '@tanstack/react-router'
import { useUser } from '@clerk/clerk-react'
import Header from '../layouts/header'
import { useEffect, useState } from 'react'
import { getProfile } from '../apiRequests/getProfile'
import UserProfile from '../components/userProfile'
import { ProfileResponse } from '../types'

export const Route = createLazyFileRoute('/profile')({
  component: Profile,
})

function Profile() {
  const { user } = useUser()
  const [profile, setProfile] = useState<ProfileResponse>()

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
