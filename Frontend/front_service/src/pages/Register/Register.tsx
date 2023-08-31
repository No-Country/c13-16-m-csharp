import React, { MutableRefObject } from 'react'
import { useState } from 'react'
import './register.css'
import logo from '../../images/logo.png'
import bg from '../../images/login-bg.png'
import { Link as Anchor } from 'react-router-dom'
import { useDispatch } from 'react-redux/es/exports'
import authActions from '../../store/auth/actions'
const { authState } = authActions

export default function Register() {
  const dispatch = useDispatch()
  const [coinciden,setCoinciden] = useState(true)

  function cambiarEstado() {
    dispatch(authState({ state: true }))
  }

  function register(e:any) {
    e.preventDefault()
    if (e.target[3].value === e.target[4].value) { // CONDICION PARA SABER SI LAS CONTRASEÑAS COINCIDEN
      setCoinciden(true)
      const data = {
        rol: e.target[0].value,
        email: e.target[1].value,
        usuario: e.target[2].value,
        contraseña: e.target[3].value,
      }
    }else{
      setCoinciden(false) // MUESTRA LA FRASE 'LAS CONTRASEÑAS NO COINCIDEN'
    }
  }

  return (
    <div className='register-hero'>
      <div className='register-data'>
        <img src={logo} alt='logo'></img>
        <div className='register-title'>
          <h2>Registrarse</h2>
          <form className='register-form' onSubmit={register}>
            <select name='select' required>
              <option value={'01'}>Cliente</option> {/* EL VALOR Y NOMBRE VAN A VENIR DINAMICAMENTE */}
              <option value={'02'}>Vendedor</option> {/* EL VALOR Y NOMBRE VAN A VENIR DINAMICAMENTE */}
            </select>
            <input type='email' name='email' placeholder='Email' required></input>
            <input type='text' name='usuario' placeholder='Usuario' required></input>
            <input type='password' name='contraseña' placeholder='Contraseña' defaultValue={''} required></input>
            <div>
              <input type='password' name='confirmar-contraseña' placeholder='Repetir Contraseña' defaultValue={''} required></input>
              <p className={coinciden ? 'fraseContraseña coinciden' : 'fraseContraseña noCoinciden'}>- Las contraseñas no coinciden -</p>
            </div>          
            <input className='submit' type='submit' value={'Registrarse'}></input>
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
