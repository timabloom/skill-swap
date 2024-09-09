import { createLazyFileRoute } from '@tanstack/react-router'

export const Route = createLazyFileRoute('/matches')({
  component: Matches,
})

function Matches() {

  return (
    <>
    </>
  )
}