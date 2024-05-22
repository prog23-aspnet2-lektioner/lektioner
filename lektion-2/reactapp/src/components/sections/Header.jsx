import React from 'react'
import { NavLink, Link } from 'react-router-dom'
import Logo from '../../assets/images/logo-light.svg'

const Header = () => {
  return (
    <header>
      <div className="container">
        <Link className="logo" to="/">
          <img src={Logo} alt="Silicon logotype" />
        </Link>

        <nav>
          <NavLink to="/">Overview</NavLink>
          <NavLink to="/features">Features</NavLink>
          <NavLink to="/contact">Contact</NavLink>
        </nav>

        <div id="theme-mode" className="btn-toggle">
          <label htmlFor="theme-mode-toggle-input">Light</label>
          <label htmlFor="theme-mode-toggle-input" className="toggle-switch">
            <input id="theme-mode-toggle-input" type="checkbox" />
            <span className="slider round"></span>
          </label>
          <label htmlFor="theme-mode-toggle-input">Dark</label>
        </div>

        <div className="account-buttons">
          <Link className="btn btn-gray" to="/signin"><i className="fa-solid fa-right-to-bracket"></i> Sign in</Link>
          <Link className="btn btn-theme" to="/signup"><i className="fa-solid fa-user"></i> Sign up</Link>
        </div>

        <button className="btn btn-bars"><i className="fa-solid fa-bars"></i></button>
      </div>
    </header>
  )
}

export default Header