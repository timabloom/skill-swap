import { SignedIn, SignedOut, SignInButton, SignOutButton, SignUpButton, useUser } from '@clerk/clerk-react'
import { Link } from '@tanstack/react-router'

function Header() {
    const { user } = useUser()

    return (
        <header className="flex items-center justify-between p-4 pl-6 pr-6">
            <Link to="/" className="[&.active]:font-bold flex gap-1">
                <p className="font-bold text-4xl">Skill</p>
                <p className="font-bold text-4xl text-yellow-500">Swap</p>
            </Link>
            <div className="flex items-center gap-4">
                <Link to="/" className="[&.active]:font-bold text-xl">
                    Home
                </Link>
                
                {user &&
                    <>
                        <Link to="/profile" className="[&.active]:font-bold text-xl">
                            Profile
                        </Link>
                        <Link to="/matches" className="[&.active]:font-bold text-xl">
                            Matches
                        </Link>
                        <Link to="/connections" className="[&.active]:font-bold text-xl">
                            Connections
                        </Link>
                    </>
                }

                <Link to="/about" className="[&.active]:font-bold text-xl">
                    About
                </Link>
                <SignedOut>
                    <SignInButton forceRedirectUrl="/profile"><button className="text-xl" >Sign In</button></SignInButton>
                </SignedOut>
                <SignedIn >
                    <SignOutButton><button className="text-xl">Sign Out</button></SignOutButton>
                </SignedIn>
                <SignedOut>
                    <SignUpButton signInForceRedirectUrl="/create-profile"><button className="btn btn-primary w-32 text-xl">Sign Up</button></SignUpButton>
                </SignedOut>
            </div>
        </header>
    )
}

export default Header