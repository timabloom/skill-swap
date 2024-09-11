import { createLazyFileRoute } from '@tanstack/react-router'
import { useUser } from '@clerk/clerk-react'
import Header from '../layouts/header'
import { getProfile } from '../apiRequests/getProfile'
import UserProfile from '../components/userProfile'
import { ProfileResponse } from '../types'
import { useQuery } from '@tanstack/react-query'

export const Route = createLazyFileRoute('/profile')({
  component: Profile,
})

function Profile() {
  const { user } = useUser()

  const { isPending, isError, data, error } = useQuery<ProfileResponse>({
    queryKey: ['profile'], queryFn: () => getProfile(user?.id)
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
      <div className="bg-primary m-10 border rounded-xl">
        <h1 className="text-6xl text-center pt-8">Profile</h1>
        <div className="flex flex-col items-center p-20 pt-10">
          <UserProfile profile={data} />
        </div>
      </div>
    </>
  )
}
