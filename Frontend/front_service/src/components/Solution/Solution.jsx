import React from 'react';
import styles from './Solution.module.css';
import SolutionImage from '../../assets/SolutionImage.webp';
import { FiDollarSign, FiBriefcase, FiZap } from "react-icons/fi";
import { PiSquaresFour } from "react-icons/pi";

export default function Solution() {
  return (
    <div className={styles.border}>
      <div className={styles.all}>
        <div>
          <div className={styles.header}>
            <h1>Libera tu tiempo y energía para lo que mejor sabes hacer</h1>
            <p>
              Nuestra aplicación revoluciona la forma en que conectas con clientes y gestionas trabajos.
              Olvídate de los detalles administrativos; la aplicación se encarga de pagos y comunicación para que
              puedas concentrarte en ofrecer tus habilidades y entregar resultados excepcionales.
            </p>
          </div>
          <div>
            <FiDollarSign color='#179CB96B' size='72px' />
            <h2>Tu Pago Seguro</h2>
            <p>
              Nuestra aplicación permite asegurar tu pago en caso de que el cliente no quiera pagar tus servicios.
            </p>
          </div>
          <div>
            <FiBriefcase color='#179CB96B' size='72px' />
            <h2>Te Ayudamos A Movilizar Tus Equipos</h2>
            <p>
              Cuenta con el soporte de transporte para que no te preocupes por tu herramienta o equipo.
            </p>
          </div>
        </div>
        <div>
          <div className={styles.image}>
            <img alt='SolutionImage' src={SolutionImage} />
          </div>
          <div>
            <PiSquaresFour color='#179CB96B' size='72px' />
            <h2>Cuenta Con Una Comunidad</h2>
            <p>
              Cuenta con varios puntos de vista y compañeros que te pueden ayudar si te ves en embrollos.
            </p>
          </div>
          <div>
            <FiZap color='#179CB96B' size='72px' />
            <h2>Risk Management</h2>
            <p>
              With experience in all market conditions, we recognize what processes and solutions.
            </p>
          </div>
        </div>
      </div>
    </div>
  )
}
