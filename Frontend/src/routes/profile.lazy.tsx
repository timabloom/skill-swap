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

  return (
    <>
      <Header />
      <div className="bg-primary m-10 border rounded-xl">
        <h1 className="text-6xl text-center pt-8">Profile</h1>
        <div className="flex flex-col items-center p-20 pt-10">
          <UserProfile profile={profile} />
        </div>
      </div>
    </>
  )
}
