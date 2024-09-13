import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'
import { ProfileResponse } from '../types'
import { useUser } from '@clerk/clerk-react'
import { getMatchingProfiles } from '../apiRequests/getMatchingProfiles'
import UserProfile from '../components/userProfile'
import { useQuery } from '@tanstack/react-query'
import { useEffect, useState } from 'react'

interface Connections {
  publicId: string,
  profileMatchPublicId: string,
  isAccepted: true
}

export const Route = createLazyFileRoute('/matches')({
  component: Matches,
})

function Matches() {
  const { user } = useUser()
  const [newConnection, setNewConnection] = useState<Connections[]>([])

  const { data } = useQuery<ProfileResponse[]>({
    queryKey: ['matches'], queryFn: () => getMatchingProfiles(user?.id),
    refetchInterval: 3000,
  })

  const [showAlert, setShowAlert] = useState(false);

  useEffect(() => {
    if (newConnection?.length === 1) {
      setTimeout(() => {
        setShowAlert(false);
      }, 5000);
      setShowAlert(true);
    }

  }, [newConnection]);

  return (
    <>
      {showAlert &&
        <div className="flex justify-center">
          <div role="alert" className="alert alert-info fixed m-2 max-w-xl">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              className="h-6 w-6 shrink-0 stroke-current">
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth="2"
                d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
            </svg>
            <span>New Connection Made!</span>
          </div>
        </div>
      }
      <Header />
      <div className="bg-yellow-300 m-10 min-h-screen border rounded-xl">
        <h1 className="text-6xl text-center pt-8">Matches</h1>
        <div className="grid grid-cols-3 gap-10 p-20 pt-10">
          {data?.map((profile) => (
            <UserProfile key={profile.publicId} profile={profile} setNewConnection={setNewConnection} />
          ))}
        </div>
      </div>
    </>
  )
}