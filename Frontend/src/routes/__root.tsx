import { SignedIn, SignedOut, SignInButton, SignOutButton } from '@clerk/clerk-react'
import { createRootRoute, Link, Outlet } from '@tanstack/react-router'
import { TanStackRouterDevtools } from '@tanstack/router-devtools'

export const Route = createRootRoute({
    component: () => (
        <>
            <header className='flex gap-4 p-4'>
                <Link to="/" className="[&.active]:font-bold">
                    Home
                </Link>
                <Link to="/profile" className="[&.active]:font-bold">
                    Profile
                </Link>
                <Link to="/matches" className="[&.active]:font-bold">
                    Matches
                </Link>
                <Link to="/connections" className="[&.active]:font-bold">
                    Connections
                </Link>
                <Link to="/about" className="[&.active]:font-bold">
                    About
                </Link>
                <SignedOut>
                    <SignInButton forceRedirectUrl="/profile"/>
                </SignedOut>
                <SignedIn >
                    <SignOutButton />
                </SignedIn>
            </header>
            <Outlet />
            <TanStackRouterDevtools />
        </>
    ),
})
