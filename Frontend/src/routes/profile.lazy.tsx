import { createLazyFileRoute, useNavigate } from '@tanstack/react-router'
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

  const navigate = useNavigate({ from: '/profile' })

  const { data } = useQuery<ProfileResponse>({
    queryKey: ['profile'], queryFn: () => getProfile(user?.id)
  })

  if (data?.clerkId !== user?.id) {
    navigate({ to: '/create-profile' })
  }

  if (data?.clerkId === user?.id) {
    return (
      <>
        <Header />
        <div className="bg-yellow-300 m-10 min-h-screen border rounded-xl">
          <h1 className="text-6xl text-center pt-8">Profile</h1>
          <div className="flex flex-col items-center p-20 pt-10">
            <UserProfile profile={data} setNewConnection={() => {}}/>
          </div>
        </div>
      </>
    )
  }

}

