import React from 'react'
import './profile.css'
import cliente1 from '../../images/cliente1.webp'
import cliente2 from '../../images/cliente2.webp'
import cliente3 from '../../images/cliente3.webp'
import flechaIzq from '../../images/flecha-izq.png'
import flechaDer from '../../images/flecha-der.png'

export default function Profile() {
  return (
    <main className='perfil-hero'>
        <h1>Clientes</h1>
        <div className='experiencia-clientes'>
            <section className='card-cliente'>
                <img src={cliente1} alt='perfil-cliente'></img>
                <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                <h3>Nombre Cliente</h3>
            </section>
            <section className='card-cliente'>
                <img src={cliente2} alt='perfil-cliente'></img>
                <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                <h3>Nombre Cliente</h3>
            </section>
            <section className='card-cliente'>
                <img src={cliente3} alt='perfil-cliente'></img>
                <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                <h3>Nombre Cliente</h3>
            </section>
        </div>
        <div className='flechas'>
            <i className="fa-solid fa-arrow-left fa-2xl"></i>
            <i className="fa-solid fa-arrow-right fa-2xl"></i>
        </div>
    </main>
  )
}
