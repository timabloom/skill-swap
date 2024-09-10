import { SignedIn, SignedOut, SignInButton, SignOutButton, SignUpButton } from '@clerk/clerk-react'
import { createRootRoute, Link, Outlet } from '@tanstack/react-router'
import { TanStackRouterDevtools } from '@tanstack/router-devtools'

export const Route = createRootRoute({
    component: () => (
        <>
            <header className="flex items-center justify-between p-4 pl-6 pr-6">
                <Link to="/" className="[&.active]:font-bold flex gap-1">
                    <p className="font-bold text-4xl">Skill</p>
                    <p className="font-bold text-4xl text-yellow-500">Swap</p>
                </Link>
                <div className="flex items-center gap-4">
                    <Link to="/" className="[&.active]:font-bold text-xl">
                        Home
                    </Link>
                    <Link to="/profile" className="[&.active]:font-bold text-xl">
                        Profile
                    </Link>
                    <Link to="/matches" className="[&.active]:font-bold text-xl">
                        Matches
                    </Link>
                    <Link to="/connections" className="[&.active]:font-bold text-xl">
                        Connections
                    </Link>
                    <Link to="/about" className="[&.active]:font-bold text-xl">
                        About
                    </Link>
                    <SignedOut>
                        <SignInButton className="text-xl" forceRedirectUrl="/profile" />
                    </SignedOut>
                    <SignedIn >
                        <SignOutButton className="text-xl" />
                    </SignedIn>
                    <SignedOut>
                        <SignUpButton className="btn btn-primary w-32 text-xl">Sign Up</SignUpButton>
                    </SignedOut>
                </div>
            </header>
            <Outlet />
            <TanStackRouterDevtools />
        </>
    ),
})
