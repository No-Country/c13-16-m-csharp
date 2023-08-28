import React from 'react'
import './register.css'
import logo from '../../images/logo.png'
import bg from '../../images/login-bg.png'
import { Link as Anchor } from 'react-router-dom'
import { useDispatch } from 'react-redux/es/exports'
import authActions from '../../store/auth/actions'
const { authState } = authActions

export default function Register() {
  const dispatch = useDispatch()

  function cambiarEstado(){
    dispatch(authState({state: true}))
  }

  return (
    <div className='register-hero'>
      <div className='register-data'>
        <img src={logo} alt='logo'></img>
        <div className='register-title'>
          <h2>Registrarse</h2>
          <form className='register-form'>
            <input type='email' name='email' placeholder='Email'></input>
            <input type='text' name='usuario' placeholder='Usuario'></input>
            <input type='password' name='contraseña' placeholder='Contraseña'></input>
            <input className='submit' type='submit' value={'Ingresar'}></input>
          </form>
        </div>
        <div className='switch-auth'>
          <p>¿Ya tienes una cuenta?</p><Anchor to={'#'} onClick={cambiarEstado}>Iniciar Sesión</Anchor> {/* el anchor tiene que cambiar el estado en redux para pasar a inicio de sesion */}
        </div>
      </div>
      <div className='background'>
        <img src={bg} alt='background'></img>
      </div>
    </div>
  )
}
