import React from 'react'
import './workerProfile.css'
import workerProfile from '../../images/workerProfile.webp'
import worker1 from '../../images/worker1.webp'
import worker2 from '../../images/worker2.webp'
import worker3 from '../../images/worker3.webp'
import flechaIzq from '../../images/flecha-izq.png'
import flechaDer from '../../images/flecha-der.png'

export default function WorkerProfile() {
    return (
        <main className='perfil-main'>
            <section className='perfil-info'>
                <img src={workerProfile} alt="profile" />
                <div className='info-text'>
                    <h1>Nombre Trabajador</h1>
                    <p>Jose cuenta con amplia experiencia en plmeria es una señor encatador y dispuesto a ayudar en lo que sea necesario</p>
                </div>
            </section>

            <div className='perfil-hero'>
                <h1>Trabajadores</h1>
                <div className='experiencia-trabajadores'>
                    <section className='card-trabajador'>
                        <img src={worker1} alt='perfil-trabajador'></img>
                        <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                        <h3>Nombre trabajador</h3>
                    </section>
                    <section className='card-trabajador'>
                        <img src={worker2} alt='perfil-trabajador'></img>
                        <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                        <h3>Nombre trabajador</h3>
                    </section>
                    <section className='card-trabajador'>
                        <img src={worker3} alt='perfil-trabajador'></img>
                        <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consequatur animi error ipsam alias ad, soluta, beatae fuga ullam accusantium asperiores quis corporis tempore obcaecati, numquam officiis inventore ut dolor temporibus.</p>
                        <h3>Nombre trabajador</h3>
                    </section>
                </div>
                <div className='flechas'>
                    <i className="fa-solid fa-arrow-left fa-2xl"></i>
                    <i className="fa-solid fa-arrow-right fa-2xl"></i>
                </div>
            </div>
        </main>
    )
}
