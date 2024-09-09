import { createLazyFileRoute } from '@tanstack/react-router'
import { postProfile } from '../apiRequests/postProfile'
import { useUser } from '@clerk/clerk-react'

export const Route = createLazyFileRoute('/profile')({
  component: Profile,
})

function Profile() {
  const { user } = useUser()

  return (
    <div>
      <img src="" alt="profile image"></img>
      <p>Name: </p>
      <p>Bio: </p>
      <p>Skills: </p>
      <p>Needs: </p>
      <p>Email:</p>
      <button onClick={() => postProfile({ clerkId: user?.id, name: 'Peter' })}>Add Profile</button>
    </div >
  )
}