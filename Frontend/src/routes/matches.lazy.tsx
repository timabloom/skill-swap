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
  console.log(user?.id)
  const { isPending, isError, data, error } = useQuery<ProfileResponse[]>({
    queryKey: ['matches'], queryFn: () => getMatchingProfiles(user?.id)
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
      <h1 className="text-3xl text-center pt-8">Matches</h1>
      <div className="flex flex-wrap gap-4">
        {data.map((profile) => (
          <UserProfile key={profile.publicId} profile={profile} />
        ))}
      </div>
    </>
  )
}