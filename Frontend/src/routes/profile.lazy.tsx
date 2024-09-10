import { createLazyFileRoute } from '@tanstack/react-router'
import { postProfile } from '../apiRequests/postProfile'
import { useUser } from '@clerk/clerk-react'
import { useForm, SubmitHandler } from "react-hook-form"
import { MouseEvent, useState } from 'react'
import Header from '../layouts/header'

export const Route = createLazyFileRoute('/profile')({
  component: Profile,
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
  "Graphic Design",
  "Cooking",
  "Gardening",
  "Tutoring",
  "Photography",
  "Writing and Editing",
  "Web Development",
  "Social Media Management",
  "Home Repairs",
  "Language Practice",
  "Event Planning",
  "Fitness Training",
  "Music Lessons",
  "Resume Writing",
  "Digital Marketing",
  "Public Speaking",
  "Time Management",
  "Basic Computer Skills",
  "Financial Planning"
];

function Profile() {
  const { user } = useUser()
  const [searchSkills, setSearchSkills] = useState<string>("")
  const [searchNeeds, setSearchNeeds] = useState<string>("")
  const [skills, setSkills] = useState<skill[]>([])
  const [needs, setNeeds] = useState<need[]>([])

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Inputs>()
  const onSubmit: SubmitHandler<Inputs> = (data) => postProfile({ ...data, clerkId: user?.id, skills: skills, needs: needs }, data.picture)

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

  return (
    <>
      <Header />
      <div className="flex items-center justify-center p-10">
        <form className="flex flex-col max-w-2xl border rounded-md p-12" onSubmit={handleSubmit(onSubmit)}>
          <h1 className="text-3xl text-center pb-8">Create Profile</h1>

          <div className="border rounded-2xl w-auto h-72 flex flex-col justify-end items-center">
            <div className="w-24 h-24 bg-gray-300 rounded-full mb-2"></div>
            <div className="w-24 h-32 bg-gray-300 rounded-t-full"></div>
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
            {skills.map((skill) => <div key={skill.tagName} className="badge badge-accent">{skill.tagName}</div>)}
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
            {needs.map((need) => <div key={need.tagName} className="badge badge-accent">{need.tagName}</div>)}
          </div>

          <h2 className="text-xl pt-10 pb-4">Contact Information</h2>
          <label className="pb-1" htmlFor="email">Email</label>
          <input className="input input-bordered input-primary w-full" {...register("email", { required: false })} />
          <button className="btn btn-primary mt-8" type="submit">Submit</button>
        </form>
      </div>
    </>
  )
}
