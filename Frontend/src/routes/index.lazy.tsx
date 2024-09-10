import { SignedOut, SignUpButton } from '@clerk/clerk-react'
import { createLazyFileRoute } from '@tanstack/react-router'

export const Route = createLazyFileRoute('/')({
    component: Index,
})

function Index() {

    return (
        <div className="flex p-2">
            <div className="p-10">
                <h1 className='mt-36 text-8xl'>Trade Skills, Build Connections!</h1>
                <div className="flex flex-col">
                    <p className="text-3xl pt-10">Register now to start collaborating and building valuable connections.</p>
                    <SignedOut>
                        <SignUpButton className="btn btn-primary w-36 text-xl mt-4">Sign Up</SignUpButton>
                    </SignedOut>
                </div>
            </div>
            <img className="p-10 pl-0 max-w-4xl rounded-" style={{ borderRadius: "25% 75% 71% 29% / 65% 69% 31% 35%" }} src="/pexels-buro-millennial-636760-1438084.avif
            " />
        </div>
    )
}