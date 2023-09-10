import React from 'react';
import HeroImage from '../../assets/HeroImage.webp';
import HeroImage2 from '../../assets/HeroImage2.webp';
import LoginImage from '../../assets/LoginImage.webp';
import styles from './Hero.module.css';
import { FiArrowRightCircle } from 'react-icons/fi';

export default function Hero() {
  return (
    <div>
      <div className={styles.wrap}>
        <img className={styles.bg} src={LoginImage} alt='LoginImage' />
        <div className={styles.all}>
          <div>
            <h1>Api-Service</h1>
            <p>
              ¿Buscás ayuda pero no estás seguro de quien llamar? ¡No te preocupés! Estamos aquí para ti, listo para resolverlo todo.
            </p>
            <button className={styles.button}>Nosotros <FiArrowRightCircle size='12px' /></button>
          </div>
          <div>
            <img className={styles.img} src={HeroImage} alt='HeroImage' />
          </div>
        </div>
      </div>
      <div>
        <div className={styles.all}>
          <div>
            <img className={styles.img} src={HeroImage2} alt='HeroImage' />
          </div>
          <div>
            <h1>Profesionales Altamente Experimentados y Apasionados</h1>
            <p>
              Nuestros expertos, con décadas de dedecación en sus respectivos campos, garantizan resultados que reflejan la excelencia de la experiencia.
            </p>
          </div>
        </div>
      </div>
    </div>
  )
}
