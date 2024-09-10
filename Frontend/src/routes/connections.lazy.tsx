import { createLazyFileRoute } from "@tanstack/react-router"
import Header from "../layouts/header"

export const Route = createLazyFileRoute('/connections')({
  component: Connections,
})

function Connections() {

  return (
    <>
      <Header />
    </>
  )
}