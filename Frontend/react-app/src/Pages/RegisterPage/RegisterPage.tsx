import React from 'react'
import * as Yup from "yup"
import { yupResolver } from "@hookform/resolvers/yup"
import { useAuth } from '../../Components/Context/useAuth';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';

interface Props { }

type RegisterFormsInputs = {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
};

const validation = Yup.object().shape({
    email: Yup.string().required("Email is required").email("Email is invalid"),
    firstName: Yup.string().required("First name is required"),
    lastName: Yup.string().required("Last name is required"),
    password: Yup.string().required("Password is required"),
});

const RegisterPage = (props: Props) => {
    const { registerUser } = useAuth();
    const { register, handleSubmit, formState: { errors }, } = useForm<RegisterFormsInputs>({ resolver: yupResolver(validation) });

    const handleLogin = (form: RegisterFormsInputs) => {
        registerUser(form.firstName, form.lastName, form.email, form.password);
    };

    return (
        <section className="bg-white rounded-lg py-5">
            <div className="container flex flex-col mx-auto bg-white rounded-lg pt-12 my-5">
                <div className="flex justify-center w-full h-full my-auto xl:gap-14 lg:justify-normal md:gap-5 draggable">
                    <div className="flex items-center justify-center w-full lg:p-12">
                        <div className="flex items-center xl:p-10">
                            <form className="flex flex-col w-full h-full pb-6 text-center bg-white rounded-3xl" onSubmit={handleSubmit(handleLogin)}>
                                <h3 className="mb-3 text-4xl font-extrabold text-dark-grey-900">Sign Up</h3>
                                <p className="mb-4 text-grey-700">Sign up using a third party service</p>
                                <a className="flex items-center justify-center w-full py-4 mb-6 text-sm font-medium transition duration-300 rounded-2xl text-grey-900 bg-grey-300 hover:bg-grey-400 focus:ring-4 focus:ring-grey-300">
                                    <img className="h-5 mr-2" src="https://raw.githubusercontent.com/Loopple/loopple-public-assets/main/motion-tailwind/img/logos/logo-google.png" alt="" />
                                    Sign up with Google
                                </a>
                                <div className="flex items-center mb-1">
                                    <hr className="h-0 border-b border-solid border-grey-500 grow" />
                                    <p className="mx-4 text-grey-600">or</p>
                                    <hr className="h-0 border-b border-solid border-grey-500 grow" />
                                </div>
                                <p className="mb-2 text-grey-700">Enter your details</p>
                                <label htmlFor="email" className="mb-2 text-sm text-start text-grey-900">Email*</label>
                                <input id="email" type="email" placeholder="mail@example.com" className={`flex items-center w-full px-4 py-3 ${errors.email ? '' : 'mb-3'} text-sm font-medium outline-none focus:bg-grey-400 ${errors.email ? '' : 'mb-7'} placeholder:text-grey-700 rounded-2xl ${errors.email ? 'border-2 border-rose-500' : 'bg-grey-200 text-dark-grey-900'}`}
                                    {...register("email")}
                                />
                                {errors.email ? <p className='text-xs px-2 text-start text-danger'>{errors.email.message}</p> : ""}
                                <label htmlFor="firstname" className="mb-2 text-sm text-start text-grey-900">First Name*</label>
                                <input id="firstname" type="text" placeholder="Enter a username" className={`flex items-center w-full px-4 py-3 ${errors.firstName ? '' : 'mb-3'} text-sm font-medium outline-none focus:bg-grey-400 ${errors.firstName ? '' : 'mb-7'} placeholder:text-grey-700 rounded-2xl ${errors.firstName ? 'border-2 border-rose-500' : 'bg-grey-200 text-dark-grey-900'}`}
                                    {...register("firstName")} />
                                {errors.firstName ? <p className='text-xs px-2 text-start text-danger'>{errors.firstName.message}</p> : ""}
                                <label htmlFor="lastName" className="mb-2 text-sm text-start text-grey-900">Last Name*</label>
                                <input id="lastName" type="text" placeholder="Enter a lastname" className={`flex items-center w-full px-4 py-3 ${errors.lastName ? '' : 'mb-3'} text-sm font-medium outline-none focus:bg-grey-400 ${errors.lastName ? '' : 'mb-7'} placeholder:text-grey-700 rounded-2xl ${errors.lastName ? 'border-2 border-rose-500' : 'bg-grey-200 text-dark-grey-900'}`}
                                    {...register("lastName")} />
                                {errors.lastName ? <p className='text-xs px-2 text-start text-danger'>{errors.lastName.message}</p> : ""}
                                <label htmlFor="password" className="mb-2 text-sm text-start text-grey-900">Password*</label>
                                <input id="password" type="password" placeholder="Enter a password" className={`flex items-center w-full px-4 py-3 ${errors.password ? '' : 'mb-4'} mr-2 text-sm font-medium outline-none focus:bg-grey-400 placeholder:text-grey-700 rounded-2xl ${errors.password ? 'border-2 border-rose-500' : 'bg-grey-200 text-dark-grey-900'}`}
                                    {...register("password")} />
                                {errors.password ? <p className='text-xs px-2 text-start text-danger'>{errors.password.message}</p> : ""}
                                <div className="flex flex-row justify-between mb-8">
                                    <label className="relative inline-flex items-center mr-3 cursor-pointer select-none">
                                        <input type="checkbox" defaultChecked value="" className="sr-only peer" />
                                        <div className="w-5 h-5 bg-white border-2 rounded-sm border-grey-500 peer peer-checked:border-0 peer-checked:bg-purple-blue-500">
                                            <img src="https://raw.githubusercontent.com/Loopple/loopple-public-assets/main/motion-tailwind/img/icons/check.png" alt="tick" />
                                        </div>
                                        <span className="ml-3 text-sm font-normal text-grey-900">Keep me logged in</span>
                                    </label>
                                </div>
                                <button className="w-full px-4 py-4 mb-3 text-sm font-bold leading-none text-white transition duration-300 md:w-96 rounded-2xl hover:bg-blue-gray-500 focus:ring-4 focus:ring-blue-gray-500 bg-blue-gray-900">Sign Up</button>
                                <p className="text-sm leading-relaxed text-grey-900">Have an account already? <Link to={'/Login'} className="font-bold text-grey-700">Sign In</Link></p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default RegisterPage