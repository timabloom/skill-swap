import { createLazyFileRoute } from "@tanstack/react-router"

export const Route = createLazyFileRoute('/connections')({
  component: Connections,
})

function Connections() {

  return (
    <>
    </>
  )
}