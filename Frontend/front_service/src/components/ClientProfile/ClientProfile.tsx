import React from 'react'
import './clientProfile.css'
import client1 from '../../images/client1.webp'
import client2 from '../../images/client2.webp'
import client3 from '../../images/client3.webp'
import flechaIzq from '../../images/flecha-izq.png'
import flechaDer from '../../images/flecha-der.png'

export default function ClientProfile() {
  return (
    <main className='perfil-hero'>
        <h1>Clientes</h1>
        <div className='experiencia-clientes'>
            <section className='card-cliente'>
                <img src={client1} alt='perfil-cliente'></img>
                <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                <h3>Nombre Cliente</h3>
            </section>
            <section className='card-cliente'>
                <img src={client2} alt='perfil-cliente'></img>
                <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                <h3>Nombre Cliente</h3>
            </section>
            <section className='card-cliente'>
                <img src={client3} alt='perfil-cliente'></img>
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
