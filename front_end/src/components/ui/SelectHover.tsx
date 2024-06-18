import PlayCircleOutlineIcon from '@mui/icons-material/PlayCircleOutline';
import Box from '@mui/material/Box';

interface ISelectHover {
    className: string;
}

const SelectHover: React.FC<ISelectHover> = ({ className }) => {
    return (
        <Box
            className={className}
            sx={{
                position: 'absolute',
                top: '0px',
                left: '0',
                right: '0',
                bottom: '0px',
                height: '100%',
                backgroundColor: 'rgba(38, 50, 56, 0.5)',
                display: 'none',
                justifyContent: 'center',
                alignItems: 'center',
            }}
        >
            <PlayCircleOutlineIcon sx={{ color: '#fff', fontSize: '48px' }} />
        </Box>
    );
};

export default SelectHover;
