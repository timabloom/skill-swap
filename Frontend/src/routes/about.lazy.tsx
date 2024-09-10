import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'

export const Route = createLazyFileRoute('/about')({
  component: About,
})

function About() {

  return (
    <>
      <Header />
    </>
  )
}