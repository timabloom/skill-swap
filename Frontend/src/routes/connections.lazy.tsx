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
    queryKey: ['connections'], queryFn: () => getConnectingProfiles(user?.id),
    refetchInterval: 3000,
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
      <div className="bg-yellow-300 m-10 min-h-screen border rounded-xl">
        <h1 className="text-6xl text-center pt-8">Connections</h1>
        <div className="grid grid-cols-3 gap-4 p-20 pt-10">
          {data.map((profile) => (
            <UserProfile key={profile.publicId} profile={profile} />
          ))}
        </div>
      </div>
    </>
  )
}