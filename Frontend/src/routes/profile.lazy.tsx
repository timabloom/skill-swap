import { createLazyFileRoute } from '@tanstack/react-router'
import { postProfile } from '../apiRequests/postProfile'
import { useUser } from '@clerk/clerk-react'
import { useForm, SubmitHandler } from "react-hook-form"

export const Route = createLazyFileRoute('/profile')({
  component: Profile,
})

type Inputs = {
  picture: FileList;
  name: string
  bio?: string
  email?: string
}

function Profile() {
  const { user } = useUser()

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Inputs>()
  const onSubmit: SubmitHandler<Inputs> = (data) => postProfile({ ...data, clerkId: user?.id }, data.picture)

  return (
    <form className="flex flex-col" onSubmit={handleSubmit(onSubmit)}>
      <input className="file-input file-input-bordered file-input-primary w-full" type="file" {...register("picture")} />
      <label htmlFor="name">Name* {errors.name && <span>This field is required</span>}</label>
      <input className="input input-bordered input-primary w-full" {...register("name", { required: true })} />
      <label htmlFor="bio">Bio</label>
      <input className="input input-bordered input-primary w-full" {...register("bio", { required: false })} />
      <p>Contact Information</p>
      <label htmlFor="email">Email</label>
      <input className="input input-bordered input-primary w-full" {...register("email", { required: false })} />
      <button className="btn btn-primary" type="submit">Submit</button>
    </form>
  )
}
