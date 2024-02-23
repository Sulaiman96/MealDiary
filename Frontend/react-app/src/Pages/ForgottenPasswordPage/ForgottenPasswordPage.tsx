import React from 'react'
import * as Yup from "yup"
import { yupResolver } from "@hookform/resolvers/yup"
import { useAuth } from '../../Components/Context/useAuth';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';

interface Props { }

type RegisterFormsInputs = {
    email: string;
};

const validation = Yup.object().shape({
    email: Yup.string().required("Email is required").email("Email is invalid")
});

const ForgottenPasswordPage = (props: Props) => {
    const { registerUser } = useAuth();
    const { register, handleSubmit, formState: { errors }, } = useForm<RegisterFormsInputs>({ resolver: yupResolver(validation) });

    // const handleLogin = (form: RegisterFormsInputs) => {
    //     forgottenPassword(form.email);
    // };

    const ForgottenPasswordPage = (props: Props) => {
        return (
            <div>ForgottenPasswordPage</div>
        )
    }
}

export default ForgottenPasswordPage