// Clapperboard mark + wordmark. The mark uses currentColor so the parent decides the colour.
export default function Logo({ withText = true }: { withText?: boolean }) {
  return (
    <>
      <svg viewBox="0 0 32 32" role="img" aria-label="Clapperboard" xmlns="http://www.w3.org/2000/svg">
        <rect x="3" y="14" width="26" height="15" rx="2.5" fill="currentColor" />
        <rect x="7" y="18" width="18" height="2" rx="1" fill="#0a0c11" />
        <rect x="7" y="23" width="11" height="2" rx="1" fill="#0a0c11" />
        <g transform="rotate(-10 3 12.5)">
          <rect x="3" y="6.5" width="26" height="6" rx="1.5" fill="currentColor" />
          <path d="M9 6.5 6 12.5h4.4l3-6zM17.4 6.5l-3 6h4.4l3-6zM25.8 6.5l-3 6h4.2l1-2V6.5z" fill="#0a0c11" />
        </g>
      </svg>
      {withText && <span>Clapperboard</span>}
    </>
  );
}
