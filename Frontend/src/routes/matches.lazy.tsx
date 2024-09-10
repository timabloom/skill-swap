import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'
import { ProfileResponse } from '../types'
import { useEffect, useState } from 'react'
import { useUser } from '@clerk/clerk-react'
import { getMatchingProfiles } from '../apiRequests/getMatchingProfiles'
import { getProfile } from '../apiRequests/getProfile'
import UserProfile from '../components/userProfile'

export const Route = createLazyFileRoute('/matches')({
  component: Matches,
})

function Matches() {
  const { user } = useUser()
  const [profiles, setProfiles] = useState<ProfileResponse[] | undefined>()

  useEffect(() => {
    const fetchProfile = async () => {
      const profile: ProfileResponse | undefined = await getProfile(user?.id)
      if (profile && profile.skills && profile.skills[0]) setProfiles(await getMatchingProfiles(profile.skills[0].tagName))
    }

    fetchProfile()
  }, [user?.id])

  return (
    <>
      <Header />
      <h1 className="text-3xl text-center pt-8">Matches</h1>
      <div className="flex flex-wrap gap-4">
        {profiles?.map((profile) => (
          <UserProfile key={profile.publicId} profile={profile} />
        ))}
      </div>
    </>
  )
}