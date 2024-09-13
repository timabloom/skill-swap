import { createFileRoute, Link } from '@tanstack/react-router'

export const Route = createFileRoute('/logo')({
  component: () => (
    <Link to="/" className="[&.active]:font-bold flex justify-center items-center h-screen">
      <p className="font-bold text-8xl">Skill</p>
      <p className="font-bold text-8xl text-yellow-500">Swap</p>
    </Link>
  )
})