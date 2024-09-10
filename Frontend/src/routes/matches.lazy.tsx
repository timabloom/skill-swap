import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'

export const Route = createLazyFileRoute('/matches')({
  component: Matches,
})

function Matches() {

  return (
    <>
      <Header />
    </>
  )
}