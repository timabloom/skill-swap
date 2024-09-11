import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'
import { ProfileResponse } from '../types'
import { useUser } from '@clerk/clerk-react'
import UserProfile from '../components/userProfile'
import { useQuery } from '@tanstack/react-query'
import { getConnectingProfiles } from '../apiRequests/getConnectingProfiles'

export const Route = createLazyFileRoute('/connections')({
  component: Connections,
})

function Connections() {
  const { user } = useUser()
  const { isPending, isError, data, error } = useQuery<ProfileResponse[]>({
    queryKey: ['matches'], queryFn: () => getConnectingProfiles(user?.id)
  })

  if (isPending) {
    return <div>Loading...</div>
  }

  if (isError) {
    return <span>Error: {error.message}</span>
  }

  return (
    <>
      <Header />
      <h1 className="text-3xl text-center pt-8">Connections</h1>
      <div className="flex flex-wrap gap-4">
        {data.map((profile) => (
          <UserProfile key={profile.publicId} profile={profile} />
        ))}
      </div>
    </>
  )
}