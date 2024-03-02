import React from 'react'
import * as Yup from "yup"
import { yupResolver } from "@hookform/resolvers/yup"
import { useAuth } from '../../Components/Context/useAuth';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';

type Props = {}

type LoginFormInputs = {
    email: string;
    password: string;
};

const validation = Yup.object().shape({
    email: Yup.string().required("Email is required").email("Email is invalid"),
    password: Yup.string().required("Password is required")

})

const LoginPage = (props: Props) => {
    const { loginUser } = useAuth();
    const { register, handleSubmit, formState: { errors } } = useForm<LoginFormInputs>({ resolver: yupResolver(validation) });

    const handleLogin = (form: LoginFormInputs) => {
        loginUser(form.email, form.password);
    };
    return (
        <section className="bg-white rounded-lg py-5">
            <div className="container flex flex-col mx-auto bg-white rounded-lg pt-12 my-5">
                <div className="flex justify-center w-full h-full my-auto xl:gap-14 lg:justify-normal md:gap-5 draggable">
                    <div className="flex items-center justify-center w-full lg:p-12">
                        <div className="flex items-center xl:p-10">
                            <form className="flex flex-col w-full h-full pb-6 text-center bg-white rounded-3xl" onSubmit={handleSubmit(handleLogin)}>
                                <h3 className="mb-3 text-4xl font-extrabold text-blue-grey-900">Sign In</h3>
                                <p className="mb-4 text-grey-700">Sign in using a third party service</p>
                                <a className="flex items-center justify-center w-full py-4 mb-6 text-sm font-medium transition duration-300 rounded-2xl text-grey-900 bg-grey-300 hover:bg-grey-400 focus:ring-4 focus:ring-grey-300">
                                    <img className="h-5 mr-2" src="https://raw.githubusercontent.com/Loopple/loopple-public-assets/main/motion-tailwind/img/logos/logo-google.png" alt="" />
                                    Sign in with Google
                                </a>
                                <div className="flex items-center mb-1">
                                    <hr className="h-0 border-b border-solid border-grey-500 grow" />
                                    <p className="mx-4 text-grey-600">or</p>
                                    <hr className="h-0 border-b border-solid border-grey-500 grow" />
                                </div>
                                <p className="mb-2 text-grey-700">Enter your email and password</p>
                                <label htmlFor="email" className="mb-2 text-sm text-start text-grey-900">Email*</label>
                                <input id="email" type="email" placeholder="mail@example.com" className={`flex items-center w-full px-4 py-3 ${errors.email ? '' : 'mb-3'} text-sm font-medium outline-none focus:bg-grey-400 ${errors.email ? '' : 'mb-7'} placeholder:text-grey-700 rounded-2xl ${errors.email ? 'border-2 border-rose-500' : 'bg-grey-200 text-dark-grey-900'}`}
                                    {...register("email")}
                                />
                                {errors.email ? <p className='text-xs px-2 text-start text-danger mt-1'>{errors.email.message}</p> : ""}
                                <label htmlFor="password" className="mb-2 text-sm text-start text-grey-900">Password*</label>
                                <input id="password" type="password" placeholder="Enter a password" className={`flex items-center w-full px-4 py-3 ${errors.password ? '' : 'mb-4'} mr-2 text-sm font-medium outline-none focus:bg-grey-400 placeholder:text-grey-700 rounded-2xl ${errors.password ? 'border-2 border-rose-500' : 'bg-grey-200 text-dark-grey-900'}`}
                                    {...register("password")} />
                                {errors.password ? <p className='text-xs px-2 text-start text-danger mt-1'>{errors.password.message}</p> : ""}
                                <div className="flex flex-row justify-between mb-8">
                                    <label className="relative inline-flex items-center mr-3 cursor-pointer select-none">
                                        <input type="checkbox" defaultChecked value="" className="sr-only peer" />
                                        <div className="w-5 h-5 bg-white border-2 rounded-sm border-grey-500 peer peer-checked:border-0 peer-checked:bg-purple-blue-500">
                                            <img src="https://raw.githubusercontent.com/Loopple/loopple-public-assets/main/motion-tailwind/img/icons/check.png" alt="tick" />
                                        </div>
                                        <span className="ml-3 text-sm font-normal text-grey-900">Keep me logged in</span>
                                    </label>
                                    <Link to={'/register'} className="mr-4 text-sm font-medium text-blue-gray-800">Forget password?</Link>
                                </div>
                                <button className="w-full px-4 py-4 mb-3 text-sm font-bold leading-none text-white transition duration-300 md:w-96 rounded-2xl hover:bg-blue-gray-500 focus:ring-4 focus:ring-blue-gray-500 bg-blue-gray-900">Sign In</button>
                                <p className="text-sm leading-relaxed text-grey-900">Not registered yet? <Link to={'/register'} className="font-bold text-blue-gray-900">Sign Up</Link></p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}

export default LoginPage