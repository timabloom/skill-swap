import { createLazyFileRoute, useNavigate } from '@tanstack/react-router'
import { postProfile } from '../apiRequests/postProfile'
import { useUser } from '@clerk/clerk-react'
import { useForm, SubmitHandler } from "react-hook-form"
import { MouseEvent, useState } from 'react'
import { useQuery } from '@tanstack/react-query'
import { getProfile } from '../apiRequests/getProfile'
import { ProfileResponse } from '../types'

export const Route = createLazyFileRoute('/create-profile')({
  component: CreateProfile,
})

type Inputs = {
  picture: FileList;
  name: string
  bio?: string
  email?: string
}

interface skill {
  tagName: string
}

interface need {
  tagName: string
}

const skillsList = [
  "JavaScript",
  "Python",
  "C++",
];

function CreateProfile() {
  const { user } = useUser()
  const [searchSkills, setSearchSkills] = useState<string>("")
  const [searchNeeds, setSearchNeeds] = useState<string>("")
  const [skills, setSkills] = useState<skill[]>([])
  const [needs, setNeeds] = useState<need[]>([])

  const navigate = useNavigate({ from: '/create-profile' })

  const { data, isLoading } = useQuery<ProfileResponse>({
    queryKey: ['profile'], queryFn: () => getProfile(user?.id)
  })

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Inputs>()
  const onSubmit: SubmitHandler<Inputs> = async (data) => {
    const profile = await postProfile({ ...data, clerkId: user?.id, skills: skills, needs: needs }, data.picture)
    if (profile) navigate({ to: '/profile' });
  }

  function handleAddSkills(event: MouseEvent<HTMLButtonElement, globalThis.MouseEvent>) {
    event.preventDefault()
    if (skillsList.includes(searchSkills) && !skills.includes({ tagName: searchSkills })) {
      setSkills([...skills, { tagName: searchSkills }])
      setSearchSkills("")
    } else {
      console.log("Skill not added")
    }
  }

  function handleAddNeeds(event: MouseEvent<HTMLButtonElement, globalThis.MouseEvent>) {
    event.preventDefault()
    if (skillsList.includes(searchNeeds) && !needs.includes({ tagName: searchNeeds })) {
      setNeeds([...needs, { tagName: searchNeeds }])
      setSearchNeeds("")
    } else {
      console.log("Need not added")
    }
  }

  if (data?.clerkId === user?.id) {
    navigate({ to: '/profile' })
  }

  if (isLoading) {
    return <div>Loading...</div>
  }

  if (data?.clerkId !== user?.id) {
    return (
      <div className="flex items-center justify-center p-10 bg-yellow-300">
        <form className="flex flex-col w-[500px] border rounded-xl p-12 bg-white" onSubmit={handleSubmit(onSubmit)}>
          <h1 className="text-3xl text-center pb-8">Create Profile</h1>

          <div className="border rounded-2xl w-auto h-80 flex flex-col justify-end items-center">
            <div className="w-28 h-28 bg-gray-300 rounded-full mb-2"></div>
            <div className="w-32 h-32 bg-gray-300 rounded-t-full"></div>
          </div>

          <input className="file-input file-input-bordered file-input-primary w-full mt-4" type="file" {...register("picture", { required: true })} />

          <label className="pt-8 pb-1" htmlFor="name">Name* {errors.name && <span>This field is required</span>}</label>
          <input className="input input-bordered input-primary w-full" {...register("name", { required: true })} />

          <label className="pt-8 pb-1" htmlFor="bio">Bio</label>
          <textarea className="textarea textarea-primary min-h-40" {...register("bio", { required: false })} />

          <label className="pt-8 pb-1" htmlFor="skills">Your skills?</label>
          <div className="flex gap-2">
            <input className="input input-bordered input-primary w-full" list="skills-list" value={searchSkills} onChange={(e) => setSearchSkills(e.target.value)} />
            <datalist id="skills-list">
              {skillsList
                .filter((option) =>
                  option.toLowerCase().slice(0, searchSkills.length) === searchSkills.toLowerCase())
                .map((option) => (
                  <option key={option}>{option}</option>
                ))}
            </datalist>
            <button className="btn btn-primary w-12 text-xl" onClick={(e) => handleAddSkills(e)}>+</button>
          </div>
          <div className="flex flex-wrap gap-1 pt-2 pb-2">
            {skills.map((skill) => <div key={skill.tagName} className="badge badge-accent p-4">{skill.tagName}</div>)}
          </div>

          <label className="pt-8 pb-1" htmlFor="needs">Need help with?</label>
          <div className="flex gap-2">
            <input className="input input-bordered input-primary w-full" list="needs-list" value={searchNeeds} onChange={(e) => setSearchNeeds(e.target.value)} />
            <datalist id="needs-list">
              {skillsList
                .filter((option) =>
                  option.toLowerCase().slice(0, searchNeeds.length) === searchNeeds.toLowerCase())
                .map((option) => (
                  <option key={option}>{option}</option>
                ))}
            </datalist>
            <button className="btn btn-primary w-12 text-xl" onClick={(e) => handleAddNeeds(e)}>+</button>
          </div>
          <div className="flex flex-wrap gap-1 pt-2 pb-2">
            {needs.map((need) => <div key={need.tagName} className="badge badge-accent p-4">{need.tagName}</div>)}
          </div>

          <h2 className="text-xl pt-10 pb-4">Contact Information</h2>
          <label className="pb-1" htmlFor="email">Email</label>
          <input className="input input-bordered input-primary w-full" {...register("email", { required: false })} />
          <button className="btn btn-primary mt-8" type="submit">Submit</button>
        </form>
      </div>
    )
  }
}

