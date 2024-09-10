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
    <div className="flex items-center justify-center p-10">
      <form className="flex flex-col max-w-96 border rounded-md p-12" onSubmit={handleSubmit(onSubmit)}>
        <h1 className="text-3xl text-center pb-8">Create Profile</h1>

        <div className="border rounded-2xl w-72 h-72 flex flex-col justify-end items-center">
          <div className="w-24 h-24 bg-gray-300 rounded-full mb-2" rounded-full ></div>
          <div className="w-24 h-32 bg-gray-300 rounded-t-full" rounded-full ></div>
        </div>

        <input className="file-input file-input-bordered file-input-primary w-full mt-4" type="file" {...register("picture")} />

        <label className="pt-8 pb-1" htmlFor="name">Name* {errors.name && <span>This field is required</span>}</label>
        <input className="input input-bordered input-primary w-full" {...register("name", { required: true })} />

        <label className="pt-8 pb-1" htmlFor="bio">Bio</label>
        <textarea className="textarea textarea-primary min-h-40" {...register("bio", { required: false })} />

        <h2 className="text-xl pt-10 pb-4">Contact Information</h2>
        <label className="pb-1" htmlFor="email">Email</label>
        <input className="input input-bordered input-primary w-full" {...register("email", { required: false })} />
        <button className="btn btn-primary mt-8" type="submit">Submit</button>
      </form>
    </div>
  )
}
