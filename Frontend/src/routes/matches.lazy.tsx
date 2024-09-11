import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'
import { ProfileResponse } from '../types'
import { useUser } from '@clerk/clerk-react'
import { getMatchingProfiles } from '../apiRequests/getMatchingProfiles'
import UserProfile from '../components/userProfile'
import { useQuery } from '@tanstack/react-query'

export const Route = createLazyFileRoute('/matches')({
  component: Matches,
})

function Matches() {
  const { user } = useUser()

  const { isPending, isError, data, error } = useQuery<ProfileResponse[]>({
    queryKey: ['matches'], queryFn: () => getMatchingProfiles(user?.id),
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
      <div className="bg-yellow-300 m-10 h-screen border rounded-xl">
        <h1 className="text-6xl text-center pt-8">Matches</h1>
        <div className="grid grid-cols-3 gap-4 p-20 pt-10">
          {data.map((profile) => (
            <UserProfile key={profile.publicId} profile={profile} />
          ))}
        </div>
      </div>
    </>
  )
}