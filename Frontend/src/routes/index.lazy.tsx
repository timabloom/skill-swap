import { SignUpButton } from '@clerk/clerk-react'
import { createLazyFileRoute } from '@tanstack/react-router'
import Header from '../layouts/header'

export const Route = createLazyFileRoute('/')({
    component: Index,
})

function Index() {

    return (
        <>
            <Header />
            <div className="flex justify-between p-2 mt-0">
                <div className="p-20 pr-0">
                    <div className="prose ml-10 mt-10">
                        <h1 className='text-8xl mb-0'>Trade Skills, Build Connections!</h1>
                        <div className="flex flex-col">
                            <p className="text-3xl">Register now to start collaborating and building valuable connections.</p>
                            <SignUpButton mode="modal" signInForceRedirectUrl="/create-profile"><button className="btn btn-primary w-40 text-2xl">Sign Up</button></SignUpButton>
                        </div>
                    </div>
                    <img className="w-[1000px] -ml-20 -mt-32 absolute z-[-1]" src="/llline.svg" alt="" />
                </div>
                <img className="p-10 mr-10 pl-0 max-w-4xl rounded" style={{ borderRadius: "25% 75% 71% 29% / 65% 69% 31% 35%" }} src="/pexels-buro-millennial-636760-1438084.avif" />
            </div>
        </>
    )
}