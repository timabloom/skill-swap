import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'

export const Route = createLazyFileRoute('/about')({
  component: About,
})

function About() {

  return (
    <>
      <Header />
      <div className="flex flex-col items-center">
        <div className="prose">
          <h1 className="text-6xl mb-0 text-center pt-8">About</h1>
          <div className="max-w-lg">

            <h2 className="text-4xl text-center font-bold mt-10 p-4 text-gray-900">Skill Swap's Roadmap</h2>

            <h3 className="text-3xl font-bold mt-10 mb-6 text-gray-900">Short-Term Goals</h3>
            <ul className="list-disc pl-4 mb-8">
              <li className="mb-2 text-2xl text-gray-600">Rating and review system for users to provide feedback after exchanges</li>
              <li className="mb-2 text-2xl text-gray-600">Recently logged in matching order</li>
              <li className="mb-2 text-2xl text-gray-600">Geolocation matching order</li>
            </ul>

            <h3 className="text-3xl font-bold mt-10 mb-6 text-gray-900">Long-Term Goals</h3>
            <ul className="list-disc pl-4 mb-8">
              <li className="mb-2 text-2xl text-gray-600">In-app messaging system for matched users to communicate</li>
              <li className="mb-2 text-2xl text-gray-600">Notification system for new matches or messages</li>
              <li className="mb-2 text-2xl text-gray-600">Scheduling feature with calendar integration for planning meetups</li>
            </ul>
          </div>
        </div>
      </div>
    </>
  )
}