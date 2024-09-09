import { createLazyFileRoute } from '@tanstack/react-router'

export const Route = createLazyFileRoute('/profile')({
  component: Profile,
})

function Profile() {

  return (
    <div>
      <img src="" alt="profile image"></img>
      <p>Name: </p>
      <p>Bio: </p>
      <p>Skills: </p>
      <p>Needs: </p>
      <p>Email:</p>
    </div>
  )
}