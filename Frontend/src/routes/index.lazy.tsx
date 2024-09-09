import { createLazyFileRoute } from '@tanstack/react-router'

export const Route = createLazyFileRoute('/')({
    component: Index,
})

function Index() {

    return (
        <>
        <h1>Trade Skills, Build Connections!</h1>
        <p>Sign up to get started</p>
        <img src="" alt="photo of two people collaborating" />
        </>
    )
}