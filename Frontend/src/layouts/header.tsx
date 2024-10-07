import { SignedIn, SignedOut, SignInButton, SignOutButton, SignUpButton, useUser } from '@clerk/clerk-react'
import { Link } from '@tanstack/react-router'

function Header() {
    const { user } = useUser()

    return (
        <header className="flex items-center justify-between p-8 pl-10 pr-10">
            <Link to="/" className="[&.active]:font-bold flex gap-1">
                <p className="font-bold text-5xl">Skill</p>
                <p className="font-bold text-5xl text-yellow-500">Swap</p>
            </Link>
            <div className="flex items-center gap-4">
                <Link to="/" className="[&.active]:font-bold text-2xl">
                    Home
                </Link>
                
                {user &&
                    <>
                        <Link to="/profile" className="[&.active]:font-bold text-2xl">
                            Profile
                        </Link>
                        <Link to="/matches" className="[&.active]:font-bold text-2xl">
                            Matches
                        </Link>
                        <Link to="/connections" className="[&.active]:font-bold text-2xl">
                            Connections
                        </Link>
                    </>
                }

                <Link to="/about" className="[&.active]:font-bold text-2xl">
                    About
                </Link>
                <SignedOut>
                    <SignInButton mode="modal" forceRedirectUrl="/profile"><button className="text-2xl" >Sign In</button></SignInButton>
                </SignedOut>
                <SignedIn >
                    <SignOutButton><button className="text-2xl">Sign Out</button></SignOutButton>
                </SignedIn>
                <SignedOut>
                    <SignUpButton mode="modal" signInForceRedirectUrl="/create-profile"><button className="btn btn-primary w-40 text-2xl">Sign Up</button></SignUpButton>
                </SignedOut>
            </div>
        </header>
    )
}

export default Header